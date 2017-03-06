using System.Numerics;

namespace Antennas
{
    public class UniformAntenna : Antenna
    {
        public override Complex Pattern(double th)
        {
            return 1;
        }
    }
}