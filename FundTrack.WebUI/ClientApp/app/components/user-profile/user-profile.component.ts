﻿import { Component, OnInit, ViewChild, AfterContentChecked, ViewContainerRef } from '@angular/core';
import { UserInfo } from '../../view-models/concrete/user-info.model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AbstractControl } from '@angular/forms';
import { EqualTextValidator } from "angular2-text-equality-validator";
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalComponent } from '../../shared/components/modal/modal-component';
import * as key from '../../shared/key.storage';
import { isBrowser } from "angular2-universal";
import { AuthorizeUserModel } from "../../view-models/concrete/authorized-user-info-view.model";
import { ChangePasswordViewModel } from "../../view-models/concrete/change-password-view-model";
import { UserService } from '../../services/concrete/user.service';
import { Router } from "@angular/router";
import { matchingPasswords } from '../registration/match-password.validator';
import { UserProfileConstantsClass } from "./user-profile.constants";


@Component({
    selector: 'user-info',
    templateUrl: './user-profile.component.html',
    styleUrls: ['./user-profile.component.css'],
    providers: [FormBuilder, UserService]
})

export class UserProfileComponent implements OnInit {
    @ViewChild(ModalComponent)

    //Modal component that contains password changes controls
    public modal: ModalComponent;

    private user: AuthorizeUserModel = new AuthorizeUserModel();
    private errorMessage: string;
    private passwordEdit: boolean = true;
    private passwordContainer: ChangePasswordViewModel = new ChangePasswordViewModel();

    //Regex pattern
    private phoneRegexPattern: string = "^[3]+[8]+[0]+[0-9]{9}$";

    /**
    Reactive forms that are bound to input elements in UI
    **/
    public userForm: FormGroup;
    public passwordForm: FormGroup;

    /**
    Object that keeps errors coming from user interface
    **/
    public formErrors = {
        "firstName": "",
        "lastName": "",
        "email": "",
        "login": "",
        "address": "",
        "newPassword": "",
        "newPasswordConfirmation": "",
        "oldPassword": "",
        "mismatchingPasswords": "",
        "phone": ""
    };

    /**
    Object that contains error messages
    **/
    public validationMessages = {
        firstName: {
            required: UserProfileConstantsClass.requiredMessage,
            minlength: UserProfileConstantsClass.minlengthMessage,
            maxlength: UserProfileConstantsClass.maxlengthMessage
        },
        lastName: {
            required: UserProfileConstantsClass.requiredMessage,
            minlength: UserProfileConstantsClass.minlengthMessage,
            maxlength: UserProfileConstantsClass.maxlengthMessage
        },
        email: {
            required: UserProfileConstantsClass.requiredMessage,
            pattern: UserProfileConstantsClass.emailFormatMessage
        },
        login: {
            required: UserProfileConstantsClass.requiredMessage,
            minlength: UserProfileConstantsClass.minlengthMessage,
            maxlength: UserProfileConstantsClass.maxlengthMessage
        },
        oldPassword: {
            required: UserProfileConstantsClass.requiredMessage
        },
        newPassword: {
            required: UserProfileConstantsClass.requiredMessage,
            minlength: UserProfileConstantsClass.minlengthMessage
        },
        newPasswordConfirmation: {
            required: UserProfileConstantsClass.requiredMessage,
            minlength: UserProfileConstantsClass.minlengthMessage,
            mismatchingPasswords: UserProfileConstantsClass.mismatchingPasswordsMessage
        },
        phone: {
            required: UserProfileConstantsClass.requiredMessage,
            pattern: UserProfileConstantsClass.phoneFormatMessage
        }
    }
    /**
     * Injecting dependencies
     * @param userService - service that handles http requests
     * @param fb - used to build forms, that will bind to elements on the page
     * @param router - used for navigation from current page
     */
    constructor(
        private userService: UserService,
        private fb: FormBuilder,
        private router: Router
    ) {
        //modalWindow.overlay.defaultViewContainer = vcRef;
    }
    /**
     * Gets user profile info from local storage
       Builds forms to bind to input elements
     */
    ngOnInit(): void {
        let data: any;
        if (isBrowser) {
            if (localStorage.getItem(key.keyToken)) {
                this.user = JSON.parse(localStorage.getItem(key.keyModel)) as AuthorizeUserModel;
            }
        };
        this.passwordContainer.login = this.user.login;
        this.buildForm();
        this.buildPasswordForm();
    }
    /**
     * Builds a form using FormBuilder and subscribes to its changes
     */
    private buildPasswordForm(): void {
        this.passwordForm = this.fb.group({
            "oldPassword": [this.passwordContainer.oldPassword, [
                Validators.required
            ]],
            "newPassword": [this.passwordContainer.newPassword, [
                Validators.required,
                Validators.minLength(7)
            ]],
            "newPasswordConfirmation": [this.passwordContainer.newPasswordConfirmation, [
                Validators.required,
                Validators.minLength(7)
            ]]
        },
            { validator: matchingPasswords('newPassword', 'newPasswordConfirmation') });

        this.passwordForm.valueChanges
            .subscribe(data => this.onValueChangePasswordForm(data));
        this.onValueChangePasswordForm();
    }
    /**
     * Builds a form using FormBuilder and subscribes to its changes
     */
    private buildForm(): void {
        this.userForm = this.fb.group({
            "firstName": [this.user.firstName, [
                Validators.required,
                Validators.minLength(2),
                Validators.maxLength(20)
            ]
            ],
            "lastName": [this.user.lastName, [
                Validators.required,
                Validators.minLength(2),
                Validators.maxLength(20)
            ]
            ],
            "email": [this.user.email, [
                Validators.required,
                Validators.pattern("[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}")
            ]],
            "login": [this.user.login, [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(20)
            ]],
            "address": [this.user.address, [
            ]],
            "phone": [this.user.phone, [
                Validators.required,
                Validators.pattern(this.phoneRegexPattern)
            ]]
        });

        this.userForm.valueChanges
            .subscribe(data => this.onValueChange(data));
        this.onValueChange();
    }
    /**
     * Handles errors in the form and selects appropriate message
     * @param data
     */
    private onValueChange(data?: any): void {
        if (!this.userForm) return;
        let form = this.userForm;

        for (let field in this.formErrors) {
            this.formErrors[field] = "";
            let control = form.get(field);

            if (control && control.dirty && !control.valid) {
                let message = this.validationMessages[field];
                for (let key in control.errors) {
                    this.formErrors[field] += message[key] + " ";
                }
            }
        }
    }
    /**
     * Handles errors in the form and selects appropriate message
     * @param data
     */
    private onValueChangePasswordForm(data?: any): void {
        if (!this.passwordForm) return;
        let form = this.passwordForm;

        for (let field in this.formErrors) {
            this.formErrors[field] = "";
            let control = form.get(field);

            if (control && control.dirty && !control.valid) {
                let message = this.validationMessages[field];
                for (let key in control.errors) {
                    this.formErrors[field] += message[key] + " ";
                }
            }
        }
    }
    /**
     * Edits user profile through uuser service and navigates to main page
     */
    public onSubmit(): void {
        this.userService.editUserProfile(this.user)
            .subscribe(data => {
                localStorage.setItem(key.keyModel, JSON.stringify(this.user));
                this.router.navigate(['/']);
            })
            ;
    }
    /**
     * Clears all password fields and opens change password modal window
     */
    private onPasswordChange(): void {
        this.passwordContainer.oldPassword = '';
        this.passwordContainer.newPassword = '';
        this.passwordContainer.newPasswordConfirmation = '';
        localStorage.removeItem(key.keyError);
        this.errorMessage = '';
        this.modal.show();
    }
    /**
     * Changes password using old and new password fields through user service component and navigates to main page if success
     */
    private changePassword(): void {
        this.userService.changePassword(this.passwordContainer)
            .subscribe(data => {
                this.passwordContainer = data;
                this.errorMessage = data.errorMessage;
                if (!this.errorMessage) {
                    localStorage.clear();
                    location.reload();
                    this.router.navigate(['/']);
                }
                else {
                }

            })
    }
    /**
     * Clears error status on changing value in password field
     */
    private refreshErrorStatus(): void {
        this.errorMessage = '';
    }
    /**
     * Gets extension of specified file
     * @param fileName: name of the file extension of which is needed to be retrieved
     */
    private getFileExtension(fileName: string): string {
        return fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
    }
}

