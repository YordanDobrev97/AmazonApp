
const btn = document.querySelector('.hamburger-button')
btn.addEventListener('click', () => {
    const menu = document.getElementById('menu');
    if (!menu.classList.contains('active')) {
        menu.style.display = 'block';
        menu.classList.add('active')
    } else {
        menu.classList.remove('active')
        menu.style.display = 'none';
    }
})
