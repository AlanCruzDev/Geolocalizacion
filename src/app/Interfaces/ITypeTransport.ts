export interface ITypeTransport {
  transports: Transport[];
  id:         number;
  nametype:   string;
}

export interface Transport {
  id:       number;
  placa:    string;
  serie:    string;
  colour:   string;
  marca:    string;
  modelo:   string;
  plazas:   number;
  status:   boolean;
  routesID: number;
  stock:    number;
}
