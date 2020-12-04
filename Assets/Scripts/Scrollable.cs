public interface Scrollable
{
    bool isX();
    float getMaxCoord();
    float getMinCoord();
    void onScrolled(float x, float y);
}