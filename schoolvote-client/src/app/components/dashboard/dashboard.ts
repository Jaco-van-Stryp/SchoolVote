import { Component, inject, OnInit, signal } from '@angular/core';
import { CreateSessionResponse, GetAllSessionsResponse, SessionsService } from '../../api';
import { SelectModule } from 'primeng/select';

@Component({
  selector: 'app-dashboard',
  imports: [SelectModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard implements OnInit {
  sessions = signal<GetAllSessionsResponse>({});

  sessionService = inject(SessionsService);

  ngOnInit(): void {
    this.loadAllSessions();
  }

  loadAllSessions() {
    this.sessionService.getAllSessions().subscribe((res: GetAllSessionsResponse) => {
      this.sessions.set(res);
    });
  }

  onSessionSelected(session: CreateSessionResponse) {
    localStorage.setItem('active_session_id', session.sessionId ?? '');
    localStorage.setItem('active_session_name', session.sessionName ?? '');
  }
}
