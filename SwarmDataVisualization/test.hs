import Data.List
import qualified Data.Vector as V

kSep :: Double
kSep = 1.0

kCoh :: Double
kCoh = -1.0

norm :: V.Vector Double -> Double
norm xs = sqrt . V.sum . V.map (^2) $ xs

sumV :: [V.Vector Double] -> V.Vector Double
sumV = foldr1 (V.zipWith (+))

aSep :: V.Vector Double -> [V.Vector Double] -> V.Vector Double
aSep p ps = V.map (* kSep) . sumV . map aI . delete p $ ps
    where aI :: V.Vector Double -> V.Vector Double
          aI pI = V.map (* (norm (V.zipWith (-) p pI)) ^^ (-2)) (V.zipWith (-) p pI)

aCoh :: V.Vector Double -> [V.Vector Double] -> V.Vector Double
aCoh p ps = V.map ((* kCoh) . (* (norm (pDist)) ^^ (-2))) pDist
    where pDist :: V.Vector Double
          pDist = V.zipWith (-) p pCm
          pCm :: V.Vector Double
          pCm = V.map (/ ((fromIntegral . length) ps)) (sumV ps)

ps = [V.fromList [1.0,1.0,1.0],V.fromList [2.0,1.0,3.0],V.fromList [0.0,0.0,1.0]]