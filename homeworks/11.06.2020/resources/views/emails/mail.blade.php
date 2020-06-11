<img src="{{ $logo }}" width="200" height="auto">
<br>
<br>
<p>
    Дякуємо за замовлення!
</p>
<table>
    @foreach($goods as $good)
        <tr style="border: 2px solid blueviolet;">
            <td>{{ $good['name'] }}</td>
            <td>{{ $good['text'] }}</td>
            <td>{{ $good['price'] }} грн</td>
        </tr>
    @endforeach
        <tr style="border: 2px solid blueviolet;">
            <td></td>
            <td></td>
            <td><strong>{{ $sum }} грн</strong></td>
        </tr>
</table>
