# Проектна задача: Слот Машина

## Тема на проектната задача
Проектната задача е имплементација на едноставна слот машина. Оваа игра е позната и забавна, при што играчите се обидуваат да освојат кредити вртејќи ролните на слот машината и добивајќи одредени комбинации на симболи.

## Работна група
Проектната задача е изработена од стдентите:
Зоран Ѓорѓијески 225003;
Андреј Велков 225126;
Мартин Ѓорѓески 221540.

## Содржина на проектната задача

### Објаснување на проблемот

**Апликација**: Имплементација на слот машина со различни симболи (на пр. цреша, лимон, бар и сл.). Играта се игра со избирање на облог и притискање на копчето "Spin" за вртење на ролните. Играчите добиваат поени според комбинациите на симболи кои се појавуваат.

**Функционалности**:
- Внесување на облог (бет) со помош на нумеричка контрола.
- Вртење на ролните и прикажување на резултатите.
- Пресметка на добивките според појавувањата на симболите.
- Прикажување на добивките и кредитите.
- Цртање на линии за големи добивки.

### Решение на проблемот

**Податоци**: Се чуваат симболите во низа од слики. Се користат нумерички променливи за кредитите, облогот и добивката.

**Структури и класи**:
- `Form1`: Главната класа на формата која го содржи кодот за слот машината.
- `IntUtil`: Класа за генерација на случајни броеви.
- `Image[] images`: Низа која ги содржи сликите за симболите.

### Функција од изворниот код

**CalculateWin**: Функција за пресметка на добивките според броењето на симболите.

```csharp
private int CalculateWin(params int[] positions)
{
    int total = 0;
    int[] symbolCounts = new int[images.Length]; // Низа за броење на симболите

    // Пресметај колку пати се појавува секој симбол
    foreach (int position in positions)
    {
        symbolCounts[position]++;
    }

    // Пресметај добивки според бројот на појавувања на симболите
    for (int i = 0; i < symbolCounts.Length; i++)
    {
        int count = symbolCounts[i];
        switch (i)
        {
            case 0: // Цреша
                ако (count >= 4) total += 5;
                else ако (count == 3) total += 2;
                else ако (count == 2) total += 1;
                break;
            case 1: // Лубеница
                ако (count >= 4) total += 6;
                else ако (count == 3) total += 1;
                break;
            case 2: // Лимон
                ако (count >= 3) total += 3;
                break;
            case 3: // Бар
                ако (count >= 4) total += 4;
                else ако (count == 3) total += 1;
                break;
            case 4: // Слива
                ако (count >= 4) total += 5;
                else ако (count == 3) total += 1;
                break;
            case 5: // Срце
                ако (count >= 4) total += 15;
                else ако (count == 3) total += 5;
                else ако (count == 2) total += 2;
                break;
            case 6: // Детелина
                ако (count >= 4) total += 15;
                else ако (count == 3) total += 7;
                else ако (count == 2) total += 2;
                ако (count >= 3) AddLinePoints(i);
                break;
            case 7: // Портокал
                ако (count >= 4) total += 7;
                else ако (count == 3) total += 4;
                else ако (count == 2) total += 1;
                break;
            case 8: // Ѕвонче
                ако (count >= 4) total += 18;
                else ако (count == 3) total += 10;
                else ако (count == 2) total += 3;
                ако (count >= 3) AddLinePoints(i);
                break;
            case 9: // Монета
                ако (count >= 4) total += 16;
                else ако (count == 3) total += 8;
                else ако (count == 2) total += 3;
                ако (count >= 3) AddLinePoints(i);
                break;
            case 10: // Потковица
                ако (count >= 4) total += 26;
                else ако (count == 3) total += 10;
                else ако (count == 2) total += 3;
                ако (count >= 3) AddLinePoints(i);
                break;
            case 11: // Грозје
                ако (count >= 4) total += 10;
                else ако (count == 3) total += 3;
                break;
            case 12: // Јаболко
                ако (count >= 4) total += 6;
                else ако (count == 3) total += 2;
                break;
            case 13: // Дијамант
                ако (count >= 4) total += 48;
                else ако (count == 3) total += 15;
                else ако (count == 2) total += 7;
                ако (count >= 3) AddLinePoints(i);
                break;
        }
    }

    // Ако има голема добивка, овозможи цртање на линијата
    ако (total > 0)
    {
        drawLine = true;
    }

    return total;
}
```
## Screenshots и кратко упатство
Screenshots:
![Слика од екранот 2024-07-05 150043](https://github.com/zokiDjordjijeski/Slot-machine-VP/assets/155031075/4ebfedf6-4568-4786-9a7b-e9bdc68ff9a5)

Главниот екран на слот машината со ролните и копчето "Spin". Екран со добивка и цртани линии за големи добивки.
![Слика од екранот 2024-07-05 150100](https://github.com/zokiDjordjijeski/Slot-machine-VP/assets/155031075/b8ab4133-47cd-4893-8e30-01dd0e6063de)


## Упатство:
Изберете облог (бет) со помош на нумеричката контрола. Притиснете "Spin" за да ги вртите ролните. Гледајте ги резултатите и проверете дали има добивка. Добиените поени се пресметуваат според комбинациите на симболите. Правила на игра Дозволено е користење на готов код или готови класи и функции како и копирање на идеи, но не е дозволено копирање и користење на готови проекти и менување на неколку функционалности. Секој обид за предавање на проектна задача која е претходно изработена за овој предмет или некој друг сличен, ќе се смета за плагијат и ќе биде најстрого санкциониран (проектната задача нема да биде признаена, што значи нема да може да се добие потпис и предметот ќе мора да се презапише).
