using System.Collections.Generic;
using System.Xml.Linq;

namespace Core;
public class Output
{
    public string Name { get; set; } = string.Empty;
    public List<Output> Children { get; set; } = new();
    public bool HasChildren => Children.Count > 0;

    public Output(string name) => Name = name;
}
