import { Injectable } from '@angular/core';

declare var QRCode;

@Injectable()
export class QRCodeService {
    generateQR(element: any, data: string) {
        var qrcode = new QRCode(element, {
            text: data,
            width: 128,
            height: 128,
            colorDark: "#000000",
            colorLight: "#ffffff",
            correctLevel: QRCode.CorrectLevel.H
        });
    }
}