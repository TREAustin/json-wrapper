## Json Wrapper - Handle conversion with complex objects.
### This library was made to handle conversion of complex objects to and from JSON strings.  The speficic use case for this library was to convert complex objects to and from Dictionary<string, dynamic> objects for Firestore.  Currently, the Firestore conversion methods in the documentation require a lot of setup and general knowledge to create custom objects.  With this library, all that was needed are attribute tags already available in the System.Text.Json.Serialization namespace.
### To use this library, a custom object must have the System.Text.Json.Serialization namespace used and the [JsonPropertyName()] attribute tag assigned to the members.  The example below shows how to setup the object.
```
using System.Text.Json.Serialization;

public class MyObject{
  [JsonPropertyName("id")]
  public int? Id {get; set;}
  
  [JsonPropertyName("name")]
  public string? Name {get; set;}
  
  [JsonPropertyName("address")]
  public string? Address {get; set;}
  
  [JsonPropertyName("favoriteFoods")]
  public List<string>? FavoriteFoods {get; set;}
}
```
### To use this for conversions, it is straightforward in code.
```
MyObject myObj = new MyObject();
string json = JsonWrapper.ToJson(myObj);
Dictionary<string,dynamic> JsonWrapper<Dictionary<string, dynmaic>(json);
```

### Since we need to convert to and from Dictionary<string, dymanic> directly, there are two methods for going to and from.  Using them would look like this,
```
MyObject myObj = new MyObject();
Dictionary<string,dynamic> dict = JsonWrapper.ToDictionary(myObj);
MyObject anotherObj = JsonWrapper.FromDictionary<MyObject>(dict);
```
