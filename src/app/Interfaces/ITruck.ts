export interface ITruck {
  id:               number;
  placa:            string;
  serie:            string;
  colour:           string;
  marca:            string;
  modelo:           string;
  plazas:           number;
  status:           boolean;
  routesID:         number;
  stock:            number;
  typeTransportID:  number;
  typeTransport:    null;
  camionEncargados: null;
}