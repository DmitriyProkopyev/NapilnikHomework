public void Enable()
{
    enable = true;
    _effects.StartEnableAnimation();
}

public void Disable()
{
    enable = false;
    _pool.Free(this);
}