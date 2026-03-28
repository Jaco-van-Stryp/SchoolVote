export * from './login.service';
import { LoginService } from './login.service';
export * from './register.service';
import { RegisterService } from './register.service';
export * from './sessions.service';
import { SessionsService } from './sessions.service';
export const APIS = [LoginService, RegisterService, SessionsService];
