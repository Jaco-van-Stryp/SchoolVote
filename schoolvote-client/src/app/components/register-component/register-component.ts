import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import {
  RegisterAdministratorCommand,
  RegisterAdministratorResponse,
  RegisterService,
} from '../../api';
import { Router, RouterLink } from '@angular/router';
import { LoginComponent } from '../login-component/login-component';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-register-component',
  imports: [InputTextModule, FormsModule, ButtonModule],
  templateUrl: './register-component.html',
  styleUrl: './register-component.scss',
})
export class RegisterComponent {
  username: string = '';
  password: string = '';

  registerService = inject(RegisterService);
  routerService = inject(Router);
  RegisterUser() {
    var user: RegisterAdministratorCommand = {
      username: this.username,
      password: this.password,
    };
    this.registerService
      .registerAdministrator(user)
      .subscribe((res: RegisterAdministratorResponse) => {
        localStorage.setItem('auth_token', res.jwt ?? '');
        this.routerService.navigate(['/Dashboard']);
      });
  }

  NavigateLogin() {
    this.routerService.navigate(['/Login']);
  }
}
