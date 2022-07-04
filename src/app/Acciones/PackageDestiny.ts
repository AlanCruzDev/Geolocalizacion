export default class PackageDestiny{

  
  public static _latitudestiny:number;
  public static _longitudedestiny:number;

  set(lnt:number, lng:number){
    PackageDestiny._latitudestiny=lnt;
    PackageDestiny._longitudedestiny=lng;
  }
  clearCoordenas(){
    PackageDestiny._latitudestiny = 0;
    PackageDestiny._longitudedestiny =0;
  }

}