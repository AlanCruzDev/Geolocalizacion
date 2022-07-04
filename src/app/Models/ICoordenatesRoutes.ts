export interface ICoordenates {
  routes:         Route[];
  id:             number;
  latOrigen:      number;
  logOrigen:      number;
  latDestination: number;
  logDestination: number;
}

export interface Route {
  id:            number;
  coordinatesID: number;
}
