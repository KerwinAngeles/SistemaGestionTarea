const url = 'https://localhost:7149/api/Tarea/Tareas-Creadas';
const contenedor = document.querySelector('data');
const modal = new bootstrap.Modal(document.getElementById('modalTarea'));
const button = document.getElementById('btn');
const form = document.querySelector('form');
let opcion = '';



button.addEventListener('click', () => {
    modal.show()
    opcion = 'crear'
})


// mostrar tarea

fetch(url)
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

on(document, 'click', '.btnEliminar', e => {
    const fila = e.target.parentNode.parentNode;
    const id = fila.firstElementChild.innerHTML;

    alertify.confirm(`Seguro que quieres eliminar la tarea ${id}.`,
        function () {
            fetch('https://localhost:7149/api/Tarea/Eliminar-Tarea?id=' + id, {
                method: 'DELETE'
            })
            .then(  res => res.json())
            .then(  location.reload())
        },
        function () {
            alertify.error('Cancel');
        });
    console.log(id);
})

let idForm = 0;

on(document, 'click', '.btnEditar', e => {
    const fila = e.target.parentNode.parentNode;
    idForm = fila.children[0].innerHTML
    const tituloForm = fila.children[1].innerHTML
    const descripcionForm = fila.children[2].innerHTML
    console.log(`ID: ${idForm} - Titulo: ${tituloForm} - Descripcion: ${descripcionForm}`)
    idTarea.value = idForm
    idTitulo.value = tituloForm
    idDescripcion.value = descripcionForm
    opcion = 'editar'
    modal.show();

})

form.addEventListener('submit', (e) =>
{
    e.preventDefault()
    if(opcion == 'crear')
    {
        fetch('https://localhost:7149/api/Tarea/CrearTarea',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id: idTarea.value,
                Titulo: idTitulo.value,
                Descripcion: idDescripcion.value,
                assignarDeveloper: "string",
                seguirTarea: true,
                Observadores: [
                    {
                        "correo": "string",
                        "contrasena": "string",
                        "rol": "string"
                    }
                ]

            })
        }).then(res => res.json())
           .then(data => {
            const nuevaTarea = []
            nuevaTarea.push(data)
            mostrarData(nuevaTarea)
           })
    }
    if(opcion == 'editar')
    {
        fetch('https://localhost:7149/api/Tarea/EditarTarea', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id: idTarea.value,
                Titulo: idTitulo.value,
                Descripcion: idDescripcion.value,
                assignarDeveloper: "string",
                seguirTarea: true,
                Observadores: [
                    {
                        "correo": "string",
                        "contrasena": "string",
                        "rol": "string"
                    }
                ]
            })
        }).then(res => res.json())
    }

    location.reload();
    modal.hide()
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
        <a class="btnEditar btn btn-primary btn-sm"> Editar</a> 
        <a class="btnEliminar btn btn-danger btn-sm"> Eliminar</a>
        </td>
        </tr>`;

    }
    document.getElementById('data').innerHTML = body;
    
}