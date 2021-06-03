using asp.net_webapi_learning.Models;

namespace asp.net_webapi_learning.Dtos.Character
{
    public class GetCharacterDto
    {
         public int Id {get;set;}
        public string Name {get;set;} = "Frodo";
        public int HitPoints {get;set;} = 100;
        public int Strenght {get;set;} = 10;
        public int Defense {get;set;} = 10;
        public int Intelligense {get;set;} = 10;
        public RpgClass Type {get;set;} = RpgClass.Knight;
    }
}