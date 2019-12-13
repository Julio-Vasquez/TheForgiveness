

function del(e, typeText)
{
    e.preventDefault();
    Swal.fire({
        title: 'Estas seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, Eliminar!',
        cancelButtonText: 'No, Cancelar!',
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            Swal.fire(
                'Eliminado!',
                `El registro de ${typeText} fue eliminado`,
                'success'
            ).then(res => {
                console.log(res);
                document.getElementById('delete').submit();
            });
        } else if ( result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Cancelado',
                `Tu registro de ${typeText} esta seguro :)`,
                'error'
            );
        }
    });
}
