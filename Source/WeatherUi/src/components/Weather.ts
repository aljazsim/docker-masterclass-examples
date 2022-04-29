import { WeatherResponse } from "./WeatherResponse";
import axios from "axios";
import { Vue } from "vue-class-component";

export default class HelloWorld extends Vue {
  public weather: WeatherResponse | null = null;

  public async mounted(): Promise<void> {
    this.weather = (await axios.create({ baseURL: process.env.VUE_APP_WEB_API_URL }).get<WeatherResponse>("weather")).data;
  }
}
