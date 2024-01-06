const form = document.getElementById('Form');

form.addEventListener('submit', event => {
    event.preventDefault();

    const id = document.getElementById('idUsuario').value;
    const nombre = document.getElementById('nombre').value;
    const correo = document.getElementById('correo').value;
    const contrasena = document.getElementById('contrasena').value;
    const canal = document.getElementById('canal').value;

    const data = {
        Id: id,
        Nombre: nombre,
        Correo: correo,
        Contrasena: contrasena,
        Rol: canal
    }

    fetch('https://localhost:7149/api/Autentication/Registro', {
        
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(res => {
        if(res.status === 200)
        {
            mostrarExito();
            return res.json().then(data => {
                console.log(data)
                localStorage.setItem('canal', tipoCuenta);
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
        title: 'Faild',
        text: message,
        icon: 'error'
    });
}

function mostrarExito()
{
    swal({
        title: 'Exitoso',
        text: 'Registro exitoso',
        icon: 'success'
    })
    setTimeout(function() {
        window.location.href = "/html/login.html";
    }, 1000);
}