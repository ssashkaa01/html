<table>
    @foreach($goods as $good)
        <tr style="border: 2px solid blueviolet;">
            <td>{{ $good['name'] }}</td>
            <td>{{ $good['text'] }}</td>
            <td>{{ $good['price'] }}</td>
        </tr>
    @endforeach
</table>
