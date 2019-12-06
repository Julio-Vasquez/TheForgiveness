
function del(e, typeText) {
    e.preventDefault();
    Swal.fire({
        title: 'Estas seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminar.'
    }).then((result) => {
        if (result.value) {
            Swal.fire(
                'Eliminado!',
                `El ${typeText} fue eliminado`,
                'success'
            ).then(res => {
                document.getElementById('delete').submit();
            });
        }
    });
}
