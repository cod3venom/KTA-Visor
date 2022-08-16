using KTA_Visor.module.Management.station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.helper
{
    public class RowHelper
    {
         public static StationTObject RowToStation(DataGridViewSelectedRowCollection row)
        {
            if (row.Count < 0) throw new ArgumentException("Row cant be empty");
            if (row[0].Cells.Count < 4) throw new ArgumentException("Selected row cells cant be empty");

            int stationId = 0;
            Int32.TryParse(row[0].Cells[0].Value.ToString(), out stationId);
            
            StationTObject station = new StationTObject();
            station.ID = stationId;
            station.IpAddress= row[0].Cells[1].Value.ToString();
            station.Name = row[0].Cells[2].Value.ToString();
            station.TotalPorts = 8;
            station.Status = row[0].Cells[4].Value.ToString(); ;

            return station;
        }
    }
}
