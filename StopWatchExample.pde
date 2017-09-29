PFont font;
int fontSize = 20;
int maxMinutes = 2;

StopWatchTimer sw = new StopWatchTimer();

void setup() {
  size(320, 240);
  font = createFont("Arial", fontSize);
  textFont(font);
  sw.start();
}

void draw() {
  background(0);
  String s = ((maxMinutes - 1) - sw.minute()) + " : " + (59 - sw.second());
  fill(255);
  textAlign(CENTER);
  text(s, width/2, height/2);
}