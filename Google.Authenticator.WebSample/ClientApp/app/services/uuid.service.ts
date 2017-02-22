import { Injectable } from '@angular/core';

// Refactored to service from https://gist.github.com/outbreak/316637cde245160c2579898b21837c1c
@Injectable()
export class UUIDService {
    public generate() {
        var that = this;
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (match) {
            return that.getRandomSymbol(match);
        });
    }

    private getRandomSymbol(symbol) {
        var array;

        if (symbol === 'y') {
            array = ['8', '9', 'a', 'b'];
            return array[Math.floor(Math.random() * array.length)];
        }

        array = new Uint8Array(1);
        window.crypto.getRandomValues(array);
        return (array[0] % 16).toString(16);
    }
}