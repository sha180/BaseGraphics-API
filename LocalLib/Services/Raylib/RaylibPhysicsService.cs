using System.Numerics;
using Raylib_cs;
using LocalLib.Casting;


namespace LocalLib.Services
{
    public class RaylibPhysicsService : PhysicsService
    {
        /// </inheritdoc>
        public bool HasCollided(AttributeBody subject, AttributeBody agent)
        {
            Raylib_cs.Rectangle subjectRectangle = ToRectangle(subject);
            Raylib_cs.Rectangle agentRectangle = ToRectangle(agent);

            // System.Console.WriteLine("player colided with " + Raylib.CheckCollisionRecs(subjectRectangle, agentRectangle) );
                    
            return Raylib.CheckCollisionRecs(subjectRectangle, agentRectangle);
        }

        public Raylib_cs.Rectangle ToRectangle(AttributeBody body)
        {
            int x = body.GetPosition().GetX();
            int y = body.GetPosition().GetY();
            int width = body.GetSize().GetX();
            int height = body.GetSize().GetY();
            return new Raylib_cs.Rectangle(x, y, width, height);
        }
    }
}