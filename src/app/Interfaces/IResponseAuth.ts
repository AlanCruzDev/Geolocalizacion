export interface IResponseAuth {
  ok:  boolean;
  msg: Msg;
}

export interface Msg {
  token:      string;
  expiracion: Date;
  rol:number;
}
