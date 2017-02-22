using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcgtemplate_web.Models
{

    public class messageComponents
    {
        public Guid patientActivityId { get; set; }
        public string phoneNum { get; set; }
        public string providerFirstName { get; set; }
        public string providerLastName { get; set; }
        public DateTime apptDateTime { get; set; }
        public string apptName { get; set; }

        public string VoiceMessage
        {
            get
            {
                var timestr = apptDateTime.ToString("t");
                var datestr = apptDateTime.ToString("dddd, MMMM d");

                var msg = $"TODO";

                return msg;
            }
        }

        public string TextMessage
        {
            get
            {
                var timestr = apptDateTime.ToString("t");
                var datestr = apptDateTime.ToString("dddd, MMMM d, yyyy");

                var msg = $"TODO";

                //TODO: Potentially include deep-linking API URL inside the Text message ??
                return msg;
            }
        }
    }
    public class message
    {
        public string Type { get; set; }
        public string Number { get; set; }
        public string Payload { get; set; }
    }

    public static class MessageData
    {
        public static messageComponents GetMessageComponentFromPatientActivity(Guid paid, string connectionString)
        {
            string sql = "TODO";
            messageComponents mc = new messageComponents();

            using (System.Data.IDbConnection conn = new Npgsql.NpgsqlConnection(connectionString))
            {
                conn.Open();
                //TODO mc = conn.Query<messageComponents>(sql, new { id = paid, phoneType = mcgtemplate_model.Models.phoneType.Mobile }).First();
            }

            return mc;
        }
    }
}
