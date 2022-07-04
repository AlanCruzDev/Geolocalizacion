import Swal from 'sweetalert2'


export const MenssageExitoConfirm=()=>{
    Swal.fire(
      'Guardado!',
      'Se Guardo Exitosamente.',
      'success'
    )
}
export const MessageNotConfirm=()=>{
  Swal.fire(
    'Cancelled',
    'Guardado Cancelado',
    'error'
  )
}
export const MessageError=()=>{
  Swal.fire(
    'Error!',
    'No se Guardo Correctamente.',
    'error'
  )
}
