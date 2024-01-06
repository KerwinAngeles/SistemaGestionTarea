const form = document.getElementById('Form');
form.addEventListener('submit', event => {
    event.preventDefault();

    const correo = document.getElementById('correo').value;
    const contrasena = document.getElementById('contrasena').value;
    const rol = document.getElementById('canal').value;

    const data = {
        Id: "0",
        Nombre: "string",
        Correo: correo,
        Contrasena: contrasena,
        Rol: rol
    }

    fetch('https://localhost:7149/api/Autentication/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(res => {
        if(res.status === 200)
        {
            mostrarExito(rol)
            return res.json().then(data => {
                console.log(data)
            });
        }
        else if(res.status === 400)
        {
            return res.text().then(error =>{
                mostrarError(error);
            });
        }
    })
    .catch(error => {
        console.error(error);
    });
    
})


function mostrarError(message){
    swal({
        title: 'Error',
        text: message,
        icon: 'error'
    });
    setTimeout(function() {
        
    }, 10)
}

function mostrarExito(rol)
{
    swal({
        title: 'Exitoso',
        text: 'Logueado Exitosamente',
        icon: 'success'
    })
    setTimeout(function() {
            if (rol === 'Lider') {
                window.location.href = "/html/task.html";

            } else if (rol === 'Desarrollador') {
                window.location.href = "/html/suscripcion.html";

            } 
    }, 1000);
}