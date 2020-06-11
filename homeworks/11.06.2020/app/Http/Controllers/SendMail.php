<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Mail;

class SendMail extends Controller
{
    public function Index(Request $request)
    {
        $goods = [
            [
                'name' => 'Samsung Galaxy 9',
                'price' => 8999,
                'text' => 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'
            ],
            [
                'name' => 'Motorola AA',
                'price' => 7799,
                'text' => 'Do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'
            ],
            [
                'name' => 'Lenovo S',
                'price' => 7099,
                'text' => 'Bore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'
            ],
            [
                'name' => 'Apple X',
                'price' => 19999,
                'text' => 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'
            ]
        ];

        $sum = 0;

        foreach ($goods as $good) {
            $sum += $good['price'];
        }

        try
        {
            Mail::send('emails.mail', [
                'goods' => $goods,
                'sum' => $sum,
                'logo' => 'https://www.seekpng.com/png/full/358-3589729_top-shopify-store-hack-shopify-logo-transparent-background.png'
            ], function ($message) use ($request){
                $message->to($request->email)->subject('тест');
            });

            return 'ВІДПРАВЛЕНО';

        }
        catch (\Exception $exception)
        {
            dd($exception);
            return 'ПОМИЛКА';
        }

        return view('emails.mail', [
            'goods' => $goods,
            'sum' => $sum,
            'logo' => 'https://www.seekpng.com/png/full/358-3589729_top-shopify-store-hack-shopify-logo-transparent-background.png'
        ]);
    }
}
