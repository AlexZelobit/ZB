1. Идеально.
2. Замечательно.
3. Тут получается так, что мы два раза ищем в DOM что - то.Первый раз мы находим.card - body, потом мы ищем внутри него все элементы.card - link.Помните что операции поиска чего - либо в DOM - это дорогостоящие операции, если есть возможность сократить это дело, то лучше сократить, в данном случае можно просто селектор прописать.card - body.card - link, он как раз найдет то что нужно сразу, то есть document.querySelectorAll('.card-body .card-link').
4. Советую всегда использовать querySelector и querySelectorAll, тем более тут надо было еще достать элементы с определенным значением у атрибута: document.querySelector('[data-number="50"]').
5. То что записано в title можно вытащить проще: console.log(document.title);
6. Верно, .parentNode или.parentElement - одно и то же, можно как угодно получать родителя.
7. Отлично.
8. Прекрасно.
Отличная работа, благодарю :)