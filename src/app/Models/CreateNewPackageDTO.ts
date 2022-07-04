export interface CreateNewPackageDTO{

  EstadoEntrega: boolean; 
  SubtotalPaquete: number;
  IvaPaquete: number;
  TotalPaquete:number;
  OrigenPaquete:string;
  DestinoPaquete:string;
  IdUser:Number;
  TypePackage:string;
  Description:string;
  PrecioPackage:number;
  CodePackage:string;
  LatOrigen:number;
  LogOrigen:number;
  LatDestination:number;
  LogDestination:number;

}