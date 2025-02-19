# Кижи Часть 1 

### Интерпретатор

##### Тестовое задание на стажировку в СКБ Контур 2020г.

Остров Кижи расположен в северной части Онежского озера. В честь острова придумали синтаксис языка Кижи, но разработчик ушел в другую команду, а интерпретатор так и остался ненаписанным. Тебе поручается написать интерпретатор по имеющемуся синтаксису и завершить начатое.

[Скачай проект KizhiPart1](https://ulearn.me/Exercise/StudentZip?courseId=backend-internship-2020&slideId=cdcc8d35-7b3a-413e-a976-136f57594ae0) и реализуй в нем метод ExecuteLine класса Interpreter

Вывод необходимо писать в передаваемый через конструктор TextWriter

Ввод передается построчно

#### Ввод
```
set a 5
sub a 3
print a
set b 4
print b
```

#### Вывод
```
2
4
```

#### Описание синтаксиса команд языка Кижи:

- set {variable} {value} - присвоить переменной {variable} значение {value}
- sub {variable} {value} - отнять из переменной {variable} значение {value}
- print {variable} - вывести значение переменной {variable}
- rem {variable} - удалить переменную {variable} из памяти

где {variable} - последовательность символов из букв английского алфавита, {value} - число из множества натуральных чисел.

#### Особенности языка Кижи

- Все переменные являются мутабельными, немутабельных переменных в языке Кижи нет. Это значит что при повторном выполнении команды set значение переменной, если она была уже в памяти заменяется.

#### Обработка ошибок, формат вывода:

Если какой-то переменной нет в памяти при интерпретации команд sub, print, rem интерпретатор должен вывести: "Переменная отсутствует в памяти"

#### Что будет проверяться:

- Корректная обработка ошибок
- Полнота реализации всех функций языка
- Простота реализации интерпретатора