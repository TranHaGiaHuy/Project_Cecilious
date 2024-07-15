let thisPage = 1;
let limit = 6;
let list = document.querySelectorAll('.listPagi .itemPagi');

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
        prev.innerText = 'Previous';
       
        prev.setAttribute('onclick', "changePage(" + (thisPage - 1) + ")");
        document.querySelector('.listPage').appendChild(prev);
    }

    for (i = 1; i <= count; i++) {
        let newPage = document.createElement('li');

        newPage.innerText = i;
        if (i == thisPage) {
            newPage.classList.add('active');
        }
        newPage.setAttribute('onclick', "changePage(" + i + ")");
        document.querySelector('.listPage').appendChild(newPage);
    }

    if (thisPage != count) {
        let next = document.createElement('li');
        next.innerText = 'Next';
        next.setAttribute('onclick', "changePage(" + (thisPage + 1) + ")");
        document.querySelector('.listPage').appendChild(next);
    }
}
function changePage(i) {
    thisPage = i;
    loadItem();
}
//=========================================================================================================================================
(function () {

	let field = document.querySelector('.items');
	let li = Array.from(field.children);

	function FilterProduct() {
		for (let i of li) {
			const name = i.querySelector('strong');
			const x = name.textContent;
			i.setAttribute("data-category", x);
		}

		let indicator = document.querySelector('.indicator').children;

		this.run = function () {
			for (let i = 0; i < indicator.length; i++) {
				indicator[i].onclick = function () {
					for (let x = 0; x < indicator.length; x++) {
						indicator[x].classList.remove('active');
					}
					this.classList.add('active');
					const displayItems = this.getAttribute('data-filter');

					for (let z = 0; z < li.length; z++) {
						li[z].style.transform = "scale(0)";
						setTimeout(() => {
							li[z].style.display = "none";
						}, 500);

						if ((li[z].getAttribute('data-category') == displayItems) || displayItems == "all") {
							li[z].style.transform = "scale(1)";
							setTimeout(() => {
								li[z].style.display = "block";
							}, 500);
						}
					}
				};
			}
		}
	}

	function SortProduct() {
		let select = document.getElementById('select');
		let ar = [];
		for (let i of li) {
			const last = i.lastElementChild;
			const x = last.textContent.trim();
			const y = Number(x.substring(1));
			i.setAttribute("data-price", y);
			ar.push(i);
		}
		this.run = () => {
			addevent();
		}
		function addevent() {
			select.onchange = sortingValue;
		}
		function sortingValue() {

			if (this.value === 'Default') {
				while (field.firstChild) { field.removeChild(field.firstChild); }
				field.append(...ar);
			}
			if (this.value === 'LowToHigh') {
				SortElem(field, li, true)
			}
			if (this.value === 'HighToLow') {
				SortElem(field, li, false)
			}
		}
		function SortElem(field, li, asc) {
			let dm, sortli;
			dm = asc ? 1 : -1;
			sortli = li.sort((a, b) => {
				const ax = a.getAttribute('data-price');
				const bx = b.getAttribute('data-price');
				return ax > bx ? (1 * dm) : (-1 * dm);
			});
			while (field.firstChild) { field.removeChild(field.firstChild); }
			field.append(...sortli);
		}
	}

	new FilterProduct().run();
	new SortProduct().run();
})();