using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestPunk.Interfaces
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(QueryFolder), typeDiscriminator: "folder")]
    [JsonDerivedType(typeof(SavedQuery), typeDiscriminator: "query")]
    public interface ITreeItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsExpanded { get; set; }
    }
}
