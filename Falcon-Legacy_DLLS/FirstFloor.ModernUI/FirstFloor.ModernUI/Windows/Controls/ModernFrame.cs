// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Windows.Controls.ModernFrame
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using FirstFloor.ModernUI.Windows.Media;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FirstFloor.ModernUI.Windows.Controls
{
  public class ModernFrame : ContentControl
  {
    public static readonly DependencyProperty KeepAliveProperty = DependencyProperty.RegisterAttached("KeepAlive", typeof (bool?), typeof (ModernFrame), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty KeepContentAliveProperty = DependencyProperty.Register(nameof (KeepContentAlive), typeof (bool), typeof (ModernFrame), new PropertyMetadata((object) true, new PropertyChangedCallback(ModernFrame.OnKeepContentAliveChanged)));
    public static readonly DependencyProperty ContentLoaderProperty = DependencyProperty.Register(nameof (ContentLoader), typeof (IContentLoader), typeof (ModernFrame), new PropertyMetadata((object) new DefaultContentLoader(), new PropertyChangedCallback(ModernFrame.OnContentLoaderChanged)));
    private static readonly DependencyPropertyKey IsLoadingContentPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsLoadingContent), typeof (bool), typeof (ModernFrame), new PropertyMetadata((object) false));
    public static readonly DependencyProperty IsLoadingContentProperty = ModernFrame.IsLoadingContentPropertyKey.DependencyProperty;
    public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof (Source), typeof (Uri), typeof (ModernFrame), new PropertyMetadata(new PropertyChangedCallback(ModernFrame.OnSourceChanged)));
    private Stack<Uri> history = new Stack<Uri>();
    private Dictionary<Uri, object> contentCache = new Dictionary<Uri, object>();
    private List<WeakReference<ModernFrame>> childFrames = new List<WeakReference<ModernFrame>>();
    private CancellationTokenSource tokenSource;
    private bool isNavigatingHistory;
    private bool isResetSource;

    public event EventHandler<FragmentNavigationEventArgs> FragmentNavigation;

    public event EventHandler<NavigatingCancelEventArgs> Navigating;

    public event EventHandler<NavigationEventArgs> Navigated;

    public event EventHandler<NavigationFailedEventArgs> NavigationFailed;

    public ModernFrame()
    {
      this.DefaultStyleKey = (object) typeof (ModernFrame);
      this.CommandBindings.Add(new CommandBinding((ICommand) NavigationCommands.BrowseBack, new ExecutedRoutedEventHandler(this.OnBrowseBack), new CanExecuteRoutedEventHandler(this.OnCanBrowseBack)));
      this.CommandBindings.Add(new CommandBinding((ICommand) NavigationCommands.GoToPage, new ExecutedRoutedEventHandler(this.OnGoToPage), new CanExecuteRoutedEventHandler(this.OnCanGoToPage)));
      this.CommandBindings.Add(new CommandBinding((ICommand) NavigationCommands.Refresh, new ExecutedRoutedEventHandler(this.OnRefresh), new CanExecuteRoutedEventHandler(this.OnCanRefresh)));
      this.CommandBindings.Add(new CommandBinding((ICommand) ApplicationCommands.Copy, new ExecutedRoutedEventHandler(this.OnCopy), new CanExecuteRoutedEventHandler(this.OnCanCopy)));
      this.Loaded += new RoutedEventHandler(this.OnLoaded);
    }

    private static void OnKeepContentAliveChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      ((ModernFrame) o).OnKeepContentAliveChanged((bool) e.NewValue);
    }

    private void OnKeepContentAliveChanged(bool keepAlive) => this.contentCache.Clear();

    private static void OnContentLoaderChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue == null)
        throw new ArgumentNullException("ContentLoader");
    }

    private static void OnSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) => ((ModernFrame) o).OnSourceChanged((Uri) e.OldValue, (Uri) e.NewValue);

    private void OnSourceChanged(Uri oldValue, Uri newValue)
    {
      if (this.isResetSource || newValue != (Uri) null && newValue.Equals((object) oldValue))
        return;
      string fragment = (string) null;
      Uri uri1 = NavigationHelper.RemoveFragment(oldValue);
      Uri uri2 = NavigationHelper.RemoveFragment(newValue, out fragment);
      if (uri2 != (Uri) null && uri2.Equals((object) uri1))
      {
        this.OnFragmentNavigation(this.Content as IContent, new FragmentNavigationEventArgs()
        {
          Fragment = fragment
        });
      }
      else
      {
        NavigationType navigationType = this.isNavigatingHistory ? NavigationType.Back : NavigationType.New;
        if (!this.isNavigatingHistory && !this.CanNavigate(oldValue, newValue, navigationType))
          return;
        this.Navigate(oldValue, newValue, navigationType);
      }
    }

    private bool CanNavigate(Uri oldValue, Uri newValue, NavigationType navigationType)
    {
      NavigatingCancelEventArgs navigatingCancelEventArgs = new NavigatingCancelEventArgs();
      navigatingCancelEventArgs.Frame = this;
      navigatingCancelEventArgs.Source = newValue;
      navigatingCancelEventArgs.IsParentFrameNavigating = true;
      navigatingCancelEventArgs.NavigationType = navigationType;
      navigatingCancelEventArgs.Cancel = false;
      NavigatingCancelEventArgs e = navigatingCancelEventArgs;
      this.OnNavigating(this.Content as IContent, e);
      if (!e.Cancel)
        return true;
      if (this.Source != oldValue)
        this.Dispatcher.BeginInvoke((Delegate) (() =>
        {
          this.isResetSource = true;
          this.SetCurrentValue(ModernFrame.SourceProperty, (object) oldValue);
          this.isResetSource = false;
        }));
      return false;
    }

    private void Navigate(Uri oldValue, Uri newValue, NavigationType navigationType)
    {
      this.SetValue(ModernFrame.IsLoadingContentPropertyKey, (object) true);
      if (this.tokenSource != null)
      {
        this.tokenSource.Cancel();
        this.tokenSource = (CancellationTokenSource) null;
      }
      if (oldValue != (Uri) null && navigationType == NavigationType.New)
        this.history.Push(oldValue);
      object newContent = (object) null;
      if (newValue != (Uri) null)
      {
        Uri newValueNoFragment = NavigationHelper.RemoveFragment(newValue);
        if (navigationType == NavigationType.Refresh || !this.contentCache.TryGetValue(newValueNoFragment, out newContent))
        {
          CancellationTokenSource localTokenSource = new CancellationTokenSource();
          this.tokenSource = localTokenSource;
          TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
          this.ContentLoader.LoadContentAsync(newValue, this.tokenSource.Token).ContinueWith((Action<Task<object>>) (t =>
          {
            try
            {
              if (t.IsCanceled || localTokenSource.IsCancellationRequested)
                return;
              if (t.IsFaulted)
              {
                NavigationFailedEventArgs e = new NavigationFailedEventArgs()
                {
                  Frame = this,
                  Source = newValue,
                  Error = t.Exception.InnerException,
                  Handled = false
                };
                this.OnNavigationFailed(e);
                newContent = e.Handled ? (object) (Exception) null : (object) e.Error;
                this.SetContent(newValue, navigationType, newContent, true);
              }
              else
              {
                newContent = t.Result;
                if (this.ShouldKeepContentAlive(newContent))
                  this.contentCache[newValueNoFragment] = newContent;
                this.SetContent(newValue, navigationType, newContent, false);
              }
            }
            finally
            {
              if (this.tokenSource == localTokenSource)
                this.tokenSource = (CancellationTokenSource) null;
              localTokenSource.Dispose();
            }
          }), scheduler);
          return;
        }
      }
      this.SetContent(newValue, navigationType, newContent, false);
    }

    private void SetContent(
      Uri newSource,
      NavigationType navigationType,
      object newContent,
      bool contentIsError)
    {
      IContent content = this.Content as IContent;
      this.Content = newContent;
      if (!contentIsError)
      {
        NavigationEventArgs navigationEventArgs = new NavigationEventArgs();
        navigationEventArgs.Frame = this;
        navigationEventArgs.Source = newSource;
        navigationEventArgs.Content = newContent;
        navigationEventArgs.NavigationType = navigationType;
        NavigationEventArgs e = navigationEventArgs;
        this.OnNavigated(content, newContent as IContent, e);
      }
      this.SetValue(ModernFrame.IsLoadingContentPropertyKey, (object) false);
      if (contentIsError)
        return;
      string fragment;
      NavigationHelper.RemoveFragment(newSource, out fragment);
      if (fragment == null)
        return;
      FragmentNavigationEventArgs e1 = new FragmentNavigationEventArgs()
      {
        Fragment = fragment
      };
      this.OnFragmentNavigation(newContent as IContent, e1);
    }

    private IEnumerable<ModernFrame> GetChildFrames()
    {
      ModernFrame modernFrame = this;
      WeakReference<ModernFrame>[] weakReferenceArray = modernFrame.childFrames.ToArray();
      for (int index = 0; index < weakReferenceArray.Length; ++index)
      {
        WeakReference<ModernFrame> r = weakReferenceArray[index];
        bool valid = false;
        ModernFrame target;
        if (r.TryGetTarget(out target) && NavigationHelper.FindFrame((string) null, (FrameworkElement) target) == modernFrame)
        {
          valid = true;
          yield return target;
        }
        if (!valid)
          modernFrame.childFrames.Remove(r);
        r = (WeakReference<ModernFrame>) null;
      }
      weakReferenceArray = (WeakReference<ModernFrame>[]) null;
    }

    private void OnFragmentNavigation(IContent content, FragmentNavigationEventArgs e)
    {
      content?.OnFragmentNavigation(e);
      if (this.FragmentNavigation == null)
        return;
      this.FragmentNavigation((object) this, e);
    }

    private void OnNavigating(IContent content, NavigatingCancelEventArgs e)
    {
      foreach (ModernFrame childFrame in this.GetChildFrames())
        childFrame.OnNavigating(childFrame.Content as IContent, e);
      e.IsParentFrameNavigating = e.Frame != this;
      content?.OnNavigatingFrom(e);
      if (this.Navigating == null)
        return;
      this.Navigating((object) this, e);
    }

    private void OnNavigated(IContent oldContent, IContent newContent, NavigationEventArgs e)
    {
      oldContent?.OnNavigatedFrom(e);
      newContent?.OnNavigatedTo(e);
      if (this.Navigated == null)
        return;
      this.Navigated((object) this, e);
    }

    private void OnNavigationFailed(NavigationFailedEventArgs e)
    {
      if (this.NavigationFailed == null)
        return;
      this.NavigationFailed((object) this, e);
    }

    private bool HandleRoutedEvent(CanExecuteRoutedEventArgs args) => args.OriginalSource is DependencyObject originalSource && originalSource.AncestorsAndSelf().OfType<ModernFrame>().FirstOrDefault<ModernFrame>() == this;

    private void OnCanBrowseBack(object sender, CanExecuteRoutedEventArgs e)
    {
      if (!this.HandleRoutedEvent(e))
        return;
      e.CanExecute = this.history.Count > 0;
    }

    private void OnCanCopy(object sender, CanExecuteRoutedEventArgs e)
    {
      if (!this.HandleRoutedEvent(e))
        return;
      e.CanExecute = this.Content != null;
    }

    private void OnCanGoToPage(object sender, CanExecuteRoutedEventArgs e)
    {
      if (!this.HandleRoutedEvent(e))
        return;
      e.CanExecute = e.Parameter is string || e.Parameter is Uri;
    }

    private void OnCanRefresh(object sender, CanExecuteRoutedEventArgs e)
    {
      if (!this.HandleRoutedEvent(e))
        return;
      e.CanExecute = this.Source != (Uri) null;
    }

    private void OnBrowseBack(object target, ExecutedRoutedEventArgs e)
    {
      if (this.history.Count <= 0 || !this.CanNavigate(this.Source, this.history.Peek(), NavigationType.Back))
        return;
      this.isNavigatingHistory = true;
      this.SetCurrentValue(ModernFrame.SourceProperty, (object) this.history.Pop());
      this.isNavigatingHistory = false;
    }

    private void OnGoToPage(object target, ExecutedRoutedEventArgs e)
    {
      Uri uri = NavigationHelper.ToUri(e.Parameter);
      this.SetCurrentValue(ModernFrame.SourceProperty, (object) uri);
    }

    private void OnRefresh(object target, ExecutedRoutedEventArgs e)
    {
      if (!this.CanNavigate(this.Source, this.Source, NavigationType.Refresh))
        return;
      this.Navigate(this.Source, this.Source, NavigationType.Refresh);
    }

    private void OnCopy(object target, ExecutedRoutedEventArgs e) => Clipboard.SetText(this.Content.ToString());

    private void OnLoaded(object sender, RoutedEventArgs e) => NavigationHelper.FindFrame("_parent", (FrameworkElement) this)?.RegisterChildFrame(this);

    private void RegisterChildFrame(ModernFrame frame)
    {
      if (this.GetChildFrames().Contains<ModernFrame>(frame))
        return;
      this.childFrames.Add(new WeakReference<ModernFrame>(frame));
    }

    private bool ShouldKeepContentAlive(object content)
    {
      if (content is DependencyObject o)
      {
        bool? keepAlive = ModernFrame.GetKeepAlive(o);
        if (keepAlive.HasValue)
          return keepAlive.Value;
      }
      return this.KeepContentAlive;
    }

    public static bool? GetKeepAlive(DependencyObject o) => o != null ? (bool?) o.GetValue(ModernFrame.KeepAliveProperty) : throw new ArgumentNullException(nameof (o));

    public static void SetKeepAlive(DependencyObject o, bool? value)
    {
      if (o == null)
        throw new ArgumentNullException(nameof (o));
      o.SetValue(ModernFrame.KeepAliveProperty, (object) value);
    }

    public bool KeepContentAlive
    {
      get => (bool) this.GetValue(ModernFrame.KeepContentAliveProperty);
      set => this.SetValue(ModernFrame.KeepContentAliveProperty, (object) value);
    }

    public IContentLoader ContentLoader
    {
      get => (IContentLoader) this.GetValue(ModernFrame.ContentLoaderProperty);
      set => this.SetValue(ModernFrame.ContentLoaderProperty, (object) value);
    }

    public bool IsLoadingContent => (bool) this.GetValue(ModernFrame.IsLoadingContentProperty);

    public Uri Source
    {
      get => (Uri) this.GetValue(ModernFrame.SourceProperty);
      set => this.SetValue(ModernFrame.SourceProperty, (object) value);
    }
  }
}
