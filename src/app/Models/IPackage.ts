export interface IPackage{
    id:              number;
    fechaEnvio:      Date;
    fechaEntrega:    Date;
    estadoEntrega:   boolean;
    subtotalPaquete: number;
    ivaPaquete:      number;
    totalPaquete:    number;
    origenPaquete:   string;
    destinoPaquete:  string;
    idRuta:          number;
    detailPackages:  null;
}