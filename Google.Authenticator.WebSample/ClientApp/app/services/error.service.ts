import { Injectable } from '@angular/core';
import * as _ from 'lodash';

@Injectable()
export class ErrorService {
    public error: mcgtemplate_web.models.Error = null;

    public showError(msg: string, details: string = null) {
        this.error = {
            message: msg,
            details: details
        }
        console.error(this.error);
    }

    public reset() {
        this.error = null;
    }

    public parseErrors(rawErrors: string[]) {
        var that = this;
        var errors: mcgtemplate_web.models.registerError[] = [];

        _.forEach(rawErrors, function (value) {
            var errorParts = value.split('|');

            errors.push({
                key: errorParts[0],
                value: errorParts[1]
            });
        });

        return errors;
    }
}