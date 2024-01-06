const modal = new bootstrap.Modal(document.getElementById('modalUsuario'));
const form = document.querySelector('form');


fetch('https://localhost:7149/api/Desarrolladores/Obtener-Desarrolladores')
    .then(res => res.json())
    .then(data => {
        mostrarData(data) 
    })
    .catch(error => console.log(error))
    const on = (element, event, selector, handler) => {
    element.addEventListener(event, e => {
        if (e.target.closest(selector)) {
            handler(e)
        }
    })
}

let idForm = 0;

on(document, 'click', '.btnAsignar', e => {
    const fila = e.target.parentNode.parentNode;
    idForm = fila.children[0].innerHTML
    const nombre = fila.children[1].innerHTML
    const correo = fila.children[2].innerHTML
    console.log(`ID: ${idForm} - Nombre: ${nombre} - Correo: ${correo}`)
    idTarea.value = idForm
    idNombre.value = nombre
    idCorreo.value = correo
    modal.show();

})

form.addEventListener('submit', (e) =>
{
    e.preventDefault()

    const data = {
        Id: idTarea.value,
        Nombre: idNombre.value,
        Correo: idCorreo.value
    }

    fetch('https://localhost:7149/api/Tarea/AsignarTarea',{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(res => res.json())
      .then(data => console.log(data))
      .catch(error => console.log(error))

    modal.hide()
})


const mostrarData = (data) => {

    console.log(data);
    let body = ' ';

    for (let index = 0; index < data.length; index++) {
        body += `
        <tr> 
        <td>${data[index].id}</td> 
        <td>${data[index].nombre}</td> 
        <td>${data[index].correo}</td> 
        <td class="text-center">
        <a class="btnAsignar btn btn-success btn-sm"> Asignar</a> 
        </td>
        </tr>`;

    }
    document.getElementById('data').innerHTML = body;
    
}