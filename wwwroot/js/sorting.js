$(document).ready(function () {
	$('#filterButton').click(function () {
		var selectedCategories = [];
		$('input[name="categoryCheckbox"]:checked').each(function () {
			selectedCategories.push($(this).val());
		});

		$.ajax({
			url: '@Url.Page("./Index", "GetFilter")',
			type: 'GET',  // Đổi sang 'GET' nếu sử dụng OnGetFilter
			data: { filRes: selectedCategories },
			success: function (data) {
				$('#resultsContainer').html(data);  // Cập nhật phần tử với dữ liệu trả về
			},
			error: function (xhr, status, error) {
				console.error('AJAX Error:', status, error);  // Xử lý lỗi nếu có
			}
		});
	});
});