import { Injectable } from '@angular/core';
import { PhoneNumberUtil, PhoneNumberFormat } from 'google-libphonenumber';

declare var libphonenumber: any;
declare var PNF: any;
declare var i18n: any;

@Injectable()
export class PhoneFormatterService {

    public formatNational(phoneVal: string, country: string = 'US'): string {

        if (phoneVal == '')
            return '';

        if (phoneVal.length < 4)
            return '';

        let phoneUtil = PhoneNumberUtil.getInstance();
        let number = phoneUtil.parseAndKeepRawInput(phoneVal, country);
        let formatted = phoneUtil.format(number, PhoneNumberFormat.NATIONAL)

        return formatted;
    }

}