import { Component, OnInit} from '@angular/core';

import { HttpUtilityService } from '../services/http-utility.service';
import { UUIDService } from '../services/uuid.service';

interface AuthData {
    key: string;
    code: string;
    qrCode: string;
    manualCode: string;
}

@Component({
    selector: 'home',
    template: require('./home.component.html')
})
export class HomeComponent {
    constructor(private httpUtility: HttpUtilityService, private uuid: UUIDService) { }

    public isLoading = false;
    public key: string;
    public twoFactorCode: string;
    public qrCodeUrl: string;
    public manualCode: string;
    public validationMessage: string;
    public validationClass: any;
    public isValid: boolean;

    ngOnInit() {
        this.generateKey();
        this.getAuthTest();
    }

    private generateKey() {
        this.key = this.uuid.generate().replace('-', '').substring(0, 10);
    }

    public getAuthTest() {
        this.httpUtility.get('/api/validate/' + this.key).subscribe(
            data => {
                this.qrCodeUrl = data.qrCode;
                this.manualCode = data.manualCode;
            },
            err => {
                console.error(err);
            }
        );
    }

    public validate() {
        console.debug('validate::');
        // barebones, nothing fancy; just re-create the model.  All Validate API needs is the key and the code
        var model: AuthData = {
            key: this.key,
            qrCode: this.qrCodeUrl,
            manualCode: this.manualCode,
            code: this.twoFactorCode
        };
        console.log(model);
        this.httpUtility.post('/api/validate', model).subscribe(
            data => {
                console.info('Success!');
                console.log(data);
                this.isValid = data.isValid;
                this.validationMessage = data.message;
            },
            err => {
                console.error(err);
            }
        );
    }

    public canValidate() {
        return this.twoFactorCode != null && this.twoFactorCode.length > 0;
    }

    public getValidationClass() {
        this.validationClass = {
            red: !this.isValid,
            green: this.isValid
        };
    }
}
