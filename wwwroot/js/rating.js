const allStar = document.querySelectorAll('.rating .star');
const ratingValue = document.querySelector('.rating input');

function setStars(value) {
	ratingValue.value = value;
	allStar.forEach((i, idx) => {
		if (idx < value) {
			i.classList.add('fas');
			i.classList.remove('far');
		} else {
			i.classList.remove('fas');
			i.classList.add('far');

		}
	});
}
window.addEventListener('load', () => {
	setStars(parseInt(ratingValue.value));
});
ratingValue.addEventListener('input', function () {
	const inputValue = parseInt(ratingValue.value);
	if (!isNaN(inputValue) && inputValue >= 0 && inputValue <= allStar.length) {
		setStars(inputValue);
	}
});

allStar.forEach((item, idx) => {
	item.addEventListener('click', function () {
		if (item.classList.contains('fas') && idx === parseInt(ratingValue.value) - 1) {
			// Clicking on the same star that is already selected, so undo the selection
			setStars(idx);
		} else {
			// Clicking on a different star or an unselected star
			setStars(idx + 1);
		}
	});
});