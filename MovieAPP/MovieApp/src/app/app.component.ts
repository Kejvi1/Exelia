import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiKey } from 'environment';

@Component({
  selector: 'app-root',
  template:
    `
    <form (ngSubmit)="SearchMovies(title)">
      <label>Search movies:</label>
      <input type="text" id="search" name="search" [(ngModel)]="title"/>
      <button type="submit">Search</button>
    </form>
    <div id="movies">
      <div *ngFor="let movie of movies">
        <h3>{{movie.Title}}</h3>
        <a href='https://www.imdb.com/title/{{movie.imdbID}}' target="_blank">
          <img [src]="movie.Poster" alt="{{movie.Title}}"/>
        </a>
      </div>
    </div>
  `,
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title: string = '';
  movies: any;

  constructor(private http: HttpClient) { }
  
  SearchMovies(title: string) {
    this.http.get(`http://www.omdbapi.com/?apikey=${apiKey}&s=${title}`).subscribe((res: any) => {
      this.movies = res.Response != 'True' ? [] : res.Search.slice(0,3);
    });
  }
}
