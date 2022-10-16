// Decompiled with JetBrains decompiler
// Type: FirstFloor.ModernUI.Resources
// Assembly: FirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=null
// MVID: 04E93C02-DCF4-4DA5-BC79-3C1A85680581
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\FirstFloor.ModernUI.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace FirstFloor.ModernUI
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  public class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static ResourceManager ResourceManager
    {
      get
      {
        if (FirstFloor.ModernUI.Resources.resourceMan == null)
          FirstFloor.ModernUI.Resources.resourceMan = new ResourceManager("FirstFloor.ModernUI.Resources", typeof (FirstFloor.ModernUI.Resources).Assembly);
        return FirstFloor.ModernUI.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
      get => FirstFloor.ModernUI.Resources.resourceCulture;
      set => FirstFloor.ModernUI.Resources.resourceCulture = value;
    }

    public static string Back => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Back), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string Cancel => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Cancel), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string Close => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Close), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string Maximize => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Maximize), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string Minimize => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Minimize), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string NavigateLink => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (NavigateLink), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string NavigationFailed => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (NavigationFailed), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string NavigationFailedFrameNotFound => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (NavigationFailedFrameNotFound), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string NavigationFailedSourceNotSpecified => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (NavigationFailedSourceNotSpecified), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string No => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (No), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string Ok => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Ok), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string Restore => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Restore), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string UIThreadRequired => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (UIThreadRequired), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string UnexpectedToken => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (UnexpectedToken), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string UnknownOS => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (UnknownOS), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string UnknownTokenType => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (UnknownTokenType), FirstFloor.ModernUI.Resources.resourceCulture);

    public static string Yes => FirstFloor.ModernUI.Resources.ResourceManager.GetString(nameof (Yes), FirstFloor.ModernUI.Resources.resourceCulture);
  }
}
