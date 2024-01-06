const modal = new bootstrap.Modal(document.getElementById('modalTarea'));
const form = document.querySelector('form');
let opcion = '';

fetch('https://localhost:7149/api/Tarea/Tareas-Creadas')
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

on(document, 'click', '.btnSuscribir', e => {
    const fila = e.target.parentNode.parentNode;
    idForm = fila.children[0].innerHTML
    const nombre = fila.children[1].innerHTML
    const correo = fila.children[2].innerHTML
    console.log(`ID: ${idForm} - Nombre: ${nombre} - Correo: ${correo}`)
    opcion = 'suscribir'
    modal.show();

})

on(document, 'click', '.btnDesuscribir', e => {
    const fila = e.target.parentNode.parentNode;
    idForm = fila.children[0].innerHTML
    const nombre = fila.children[1].innerHTML
    const correo = fila.children[2].innerHTML
    console.log(`ID: ${idForm} - Nombre: ${nombre} - Correo: ${correo}`)
    opcion = 'desuscribir'
    modal.show();

})


form.addEventListener('submit', (e) =>
{
    e.preventDefault()

    if(opcion == 'suscribir')
    {
        const data = {
            Id: idTarea.value,
            Nombre: idNombre.value,
            Correo: idCorreo.value
        }
    
        fetch('https://localhost:7149/api/Suscripcion/Seguir-Tarea',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then(res => res.json())
          .then(data => console.log(data))
          .catch(error => console.log(error))
    
        modal.hide()
    }

    if(opcion == 'desuscribir')
    {
        const data = {
            Id: idTarea.value,
            Nombre: idNombre.value,
            Correo: idCorreo.value
        }
    
        fetch('https://localhost:7149/api/Suscripcion/Dejar-Tarea',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then(res => res.json())
          .then(data => console.log(data))
          .catch(error => console.log(error))
    
        modal.hide()
    }
})


const mostrarData = (data) => {

    console.log(data);
    let body = ' ';

    for (let index = 0; index < data.length; index++) {
        body += `
        <tr> 
        <td>${data[index].id}</td> 
        <td>${data[index].titulo}</td> 
        <td>${data[index].descripcion}</td> 
        <td class="text-center">
        <a class="btnSuscribir btn btn-primary btn-sm"> Suscribir</a> 
        <a class="btnDesuscribir btn btn-danger btn-sm"> Desuscribir</a> 
        </td>
        </tr>`;

    }
    document.getElementById('data').innerHTML = body;
    
}