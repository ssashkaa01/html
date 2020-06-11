<?php

use Illuminate\Support\Facades\Route;

Route::get('/send/{email}', 'SendMail@Index');
