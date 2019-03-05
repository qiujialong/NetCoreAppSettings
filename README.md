# NetCoreAppSettings
.net Core 2.0+ 项目获取appsettings.json中的值

{

  "Caching": {
  
      "CachingPolicy": "redis", 
      
      "Db": 6
      
    },
    
  "Port": "7779"
  
}


    
AppSettings.GetValue("Port");

AppSettings.GetSection<CachingModel>("Caching");



class CachingModel

{

     public string CachingPolicy { get; set; }
     
     public int Db { get; set; }
     
}
