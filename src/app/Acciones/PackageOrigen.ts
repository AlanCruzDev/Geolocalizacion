

export  default class PackageOrigen{

  public static _latitude:number;
  public static _longitude:number;

  set(lnt:number, lng:number){
    PackageOrigen._latitude=lnt;
    PackageOrigen._longitude=lng;
  }
  clearCoordenas(){
    PackageOrigen._latitude = 0;
    PackageOrigen._longitude =0;
  }
}