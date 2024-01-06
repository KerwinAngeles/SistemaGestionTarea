const toggle = document.querySelector('.toggle');
const toggleIcon = document.querySelector('.toggle i');
const menu = document.querySelector('.menu');


toggle.onclick = function(){
    menu.classList.toggle('open')
    const isOpen = menu.classList.contains('open');
    toggleIcon.classList = isOpen
    ? 'fa-solid fa-xmark'
    : 'fa-solid fa-bars'
}