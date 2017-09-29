int maxMinutes = 2;

StopWatchTimer sw = new StopWatchTimer();

void setup() {
  sw.start();
}

void draw() {
  println(((maxMinutes - 1) - sw.minute()) + " " + (59 - sw.second()));  // instead of just seconds();
}