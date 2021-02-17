using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Database.Entities.Database
{
    public abstract class JsonDatabaseEntity<T> where T : new()
    {
        [Column("jsondata", TypeName = "jsonb")]
        [Required]
        public string JsonData { get; set; }

        public T GetData()
        {
            if (string.IsNullOrWhiteSpace(this.JsonData))
                return new T();
            return JsonConvert.DeserializeObject<T>(this.JsonData);
        }

        public void SetData(T settings) =>
            this.JsonData = JsonConvert.SerializeObject(settings);
    }
}
