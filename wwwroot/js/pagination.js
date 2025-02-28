﻿let thisPage = 1;
let limit = 6;
let list = document.querySelectorAll('.list .item');
function loadItem() {
    let beginGet = limit * (thisPage - 1);
    let endGet = limit * thisPage - 1;
    list.forEach((item, key) => {
        if (key >= beginGet && key <= endGet) {
            item.style.display = 'block';
        } else {
            item.style.display = 'none';
        }

    })
    listPage();
}
loadItem();
function listPage() {
    let count = Math.ceil(list.length / limit);
    document.querySelector('.listPage').innerHTML = '';

    if (thisPage != 1) {
        let prev = document.createElement('li');
        prev.classList.add('page-item');
        prev.id = 'scrollToTopButton';


        prev.innerText = 'PREV';
        prev.setAttribute('onclick', "changePage(" + (thisPage - 1) + ")");
        document.querySelector('.listPage').appendChild(prev);
    }

    for (i = 1; i <= count; i++) {
        let newPage = document.createElement('li');
        newPage.classList.add('page-item');
        newPage.id = 'scrollToTopButton';
        newPage.innerText = i;
        if (i == thisPage) {
            newPage.classList.add('active');
        }
        newPage.setAttribute('onclick', "changePage(" + i + ")");
        document.querySelector('.listPage').appendChild(newPage);
    }

    if (thisPage != count) {
        let next = document.createElement('li');
        next.classList.add('page-item');
        next.id = 'scrollToTopButton';


        next.innerText = 'NEXT';
        next.setAttribute('onclick', "changePage(" + (thisPage + 1) + ")");
        document.querySelector('.listPage').appendChild(next);
    }
}
function changePage(i) {
    thisPage = i;
    loadItem();
}
const scrollToTopButton = document.getElementById('scrollToTopButton');

scrollToTopButton.addEventListener('click', function () {
    window.scrollTo({ top: 0, behavior: 'smooth' });
});